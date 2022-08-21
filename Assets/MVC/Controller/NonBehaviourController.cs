using System.Collections;

namespace MVC.Component
{
    public interface IController
    {
        public IEnumerator Initialize();
        public IEnumerator Finalize();
        public IEnumerator Terminate();
    }
}
