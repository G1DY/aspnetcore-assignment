namespace Queue_Management_System
{
    public class StartUp
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Other configuration...

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
