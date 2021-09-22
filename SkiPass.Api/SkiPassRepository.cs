namespace SkiPass.Api
{
    internal class SkiPassRepository
    {
        public void CreatePass(SkiPass pass)
        {
            var context = new SkiPassContext();
            pass.ID = new Guid();
            context.Passes.Add(pass);
            context.SaveChanges();

        }
    }
}
