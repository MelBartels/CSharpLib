using System;
using System.Linq;
using Xunit;

namespace GenLibUnitTests.Examples.MVVM
{
    public class ViewMediator
    {
        [Fact]
        public void Interaction()
        {
            const string model = "model";
            var viewFake = new ViewFake();
            var updateViewMediator = new UpdateViewMediator();

            // wire updateViewMediator to viewFake 
            var alert = Observable.FromEvent<ModelEventArgs>(updateViewMediator, "Action");
            alert.Subscribe(e => viewFake.UpdateModel(updateViewMediator, e.EventArgs));

            updateViewMediator.Execute(this, new ModelEventArgs {Model = model});
            Assert.Equal(model, viewFake.DisplayText);

            const string updatedModel = "updated model";
            var viewUpdatedMediator = new ViewUpdatedMediator();

            // wire viewFake to viewUpdatedMediator
            var action = Observable.FromEvent<ModelEventArgs>(viewFake, "Alert");
            action.Subscribe(e => viewUpdatedMediator.Execute(viewFake, e.EventArgs));

            viewFake.DisplayText = updatedModel;
            viewFake.AlertModelUpdatedObservers();
            Assert.Equal(updatedModel, viewUpdatedMediator.Model);
        }

        #region Nested type: ModelEventArgs

        public class ModelEventArgs : EventArgs
        {
            public string Model { get; set; }
        }

        #endregion

        #region Nested type: UpdateViewMediator

        public class UpdateViewMediator
        {
            public event EventHandler<ModelEventArgs> Action;

            public void Execute(object sender, ModelEventArgs ags)
            {
                Action(sender, ags);
            }
        }

        #endregion

        #region Nested type: ViewFake

        public class ViewFake
        {
            public string DisplayText { get; set; }

            public object Model
            {
                get { return DisplayText; }
                set { DisplayText = value as string; }
            }

            public event EventHandler<ModelEventArgs> Alert;

            public void AlertModelUpdatedObservers()
            {
                Alert(this, new ModelEventArgs {Model = DisplayText});
            }

            public void UpdateModel(object sender, ModelEventArgs args)
            {
                Model = args.Model;
            }
        }

        #endregion

        #region Nested type: ViewUpdatedMediator

        public class ViewUpdatedMediator
        {
            public string Model { get; set; }

            public void Execute(object sender, ModelEventArgs args)
            {
                Model = args.Model;
            }
        }

        #endregion
    }
}