using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace TeliaCore.Infrastructure
{
	public class WindsorControllerFactory : DefaultControllerFactory
	{
		private readonly IWindsorContainer _windsorContainer;

		public WindsorControllerFactory(IWindsorContainer windsorContainer)
		{
			this._windsorContainer = windsorContainer;
		}

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                return (IController)_windsorContainer.Resolve(controllerType);
            }
            
            return base.GetControllerInstance(requestContext, null);
        }


	    public override void ReleaseController(IController controller)
		{
			var disposableController = controller as IDisposable;
			if (disposableController != null)
			{
				disposableController.Dispose();
			}

			_windsorContainer.Release(controller);
		}
	}
}
