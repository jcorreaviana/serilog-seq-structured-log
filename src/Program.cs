using System;
using Serilog;

namespace SerializedLog
{
    class Program
    {
        static void Main(string[] args)
        {

            ILogger log = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger(); 

                for (int i = 0; i < 1500; i++)
                {
                    var request = new 
                    {
                        TransactionId = Guid.NewGuid(),
                        Message = "OK",
                        Response = "Usuário salvo com sucesso!"
                    };

                    log.Information("New request transactionId: {TransactionID}: {@request}", request.TransactionId, request);
                    
                }

                Console.Read();
        }
    }
}
