namespace SkiPass.Api
{
    public class SkiPassRepository
    {
        public void CreatePass(SkiPass pass)
        {
            var context = new SkiPassContext();
            context.Passes.Add(pass);
            context.SaveChanges();
        }
    }
}
