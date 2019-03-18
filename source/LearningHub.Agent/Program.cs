using LearningHub.Database.Course;
using LearningHub.Database.Database;
using LearningHub.Database.Student;
using LearningHub.Domain;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearningHub.Agent
{
    public class Program
    {
        private IQueueClient queuClient;
        private IDatabaseUnitOfWork databaseUnitOfWork;
        private IStudentRepository studentRepository;
        private ICourseRepository courseRepository;
        private StudentDomain studentDomain;

        private static void Main()
        {
            Program program = new Program();
            program.MainAsync().GetAwaiter().GetResult();
        }

        private async Task MainAsync()
        {
            queuClient = new QueueClient(Environment.GetEnvironmentVariable("LearningHub_AzureServiceBus"), Environment.GetEnvironmentVariable("LearningHub_QueueName"));
            DatabaseContextFactory dbFactory = new DatabaseContextFactory();
            var databaseContext = dbFactory.CreateDbContext(new string[] { });
            databaseUnitOfWork = new DatabaseUnitOfWork(databaseContext);
            studentRepository = new StudentRepository(databaseContext);
            courseRepository = new CourseRepository(databaseContext);
            studentDomain = new StudentDomain(databaseUnitOfWork, studentRepository, courseRepository);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to stop receiving messages and exit.");
            Console.WriteLine("======================================================");

            // Register the queue message handler and receive messages in a loop
            RegisterOnMessageHandlerAndReceiveMessages();

            Console.ReadKey();

            await queuClient.CloseAsync();
        }

        private void RegisterOnMessageHandlerAndReceiveMessages()
        {
            // Configure the message handler options in terms of exception handling, number of concurrent messages to deliver, etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of concurrent calls to the callback ProcessMessagesAsync(), set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Indicates whether the message pump should automatically complete the messages after returning from user callback.
                // False below indicates the complete operation is handled by the user callback as in ProcessMessagesAsync().
                AutoComplete = false
            };

            // Register the function that processes messages.
            queuClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            // Process the message.
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            
            var student = studentDomain.ConvertToStudentEntity(Encoding.UTF8.GetString(message.Body));
            string errorMessage = await studentDomain.ApplyBusinessRules(student);

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                SendMail("Student not added, " + errorMessage);
            }
            else
            {
                await studentRepository.AddAsync(student);
                await databaseUnitOfWork.SaveChangesAsync();

                SendMail($"Student added Successfully. StudentId:{student.StudentId}");
            }

            // Complete the message so that it is not received again.
            // This can be done only if the queue Client is created in ReceiveMode.PeekLock mode (which is the default).
            await queuClient.CompleteAsync(message.SystemProperties.LockToken);

            // Note: Use the cancellationToken passed as necessary to determine if the queueClient has already been closed.
            // If queueClient has already been closed, you can choose to not call CompleteAsync() or AbandonAsync() etc.
            // to avoid unnecessary exceptions.
        }

        // Use this handler to examine the exceptions received on the message pump.
        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }

        private void SendMail(string emailMessage)
        {
            Console.WriteLine("Email:" + emailMessage);
        }
    }
}
