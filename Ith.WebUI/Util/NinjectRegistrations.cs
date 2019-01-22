using Ith.Domain.Abstract;
using Ith.Domain.Concrete;
using Ninject.Modules;

namespace Ith.WebUI.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IPostRepository>().To<PostRepository>();
        }
    }
}