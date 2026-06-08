using LoginModule.Models;
using Supabase;

namespace LoginModule.Services
{
    public class SupabaseService
    {
        public Client Client { get; private set; }

        public SupabaseService()
        {
            var url = "https://mnpcrbwulkplqgfqkooc.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im1ucGNyYnd1bGtwbHFnZnFrb29jIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Nzg0ODM0MzAsImV4cCI6MjA5NDA1OTQzMH0._upzxBMsOhRFoP38r3AhKdvRI1nCRPR0oee9sy8iVoI";

            Client = new Client(url, key);

            Client.InitializeAsync().Wait();
        }




        public async Task<UserModel> Login(string email, string password)
        {
            var response = await Client
                .From<UserModel>()
                .Filter("email", Supabase.Postgrest.Constants.Operator.Equals, email)
                .Filter("password", Supabase.Postgrest.Constants.Operator.Equals, password)
                .Get();

            return response.Models.FirstOrDefault();
        }




        //debugger
        //public async Task<UserModel> Login(string email, string password)
        //{
        //    var response = await Client
        //        .From<UserModel>()
        //        .Get();

        //    return response.Models.FirstOrDefault();
        //}


    }
}