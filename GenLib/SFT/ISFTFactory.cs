using System;
using GenLib.ExceptionService;
using GenLib.Extensions;

namespace GenLib.SFT
{
    public class ISFTFactory
    {
        public ISFTFactory(IExceptionHandler exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
        }

        public ISFTFactory() : this(new ExceptionHandlerLog())
        {
        }

        private IExceptionHandler ExceptionHandler { get; set; }

        public ISFTFacade Build(string typeName)
        {
            return Type.GetType(typeName)
                .With(t => Activator.CreateInstance(t)
                               .CastSafe<ISFTFacade>()
                               .DoWhenNull(() => ExceptionHandler.Notify("Could not build ISFTFacade " + typeName)));
        }
    }
}