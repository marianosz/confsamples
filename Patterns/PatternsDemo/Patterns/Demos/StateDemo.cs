using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.Demos
{
    class StateDemo
    {
        public static void Run()
        {
            // Setup context in a state
            StateContext c = new StateContext(new ConcreteStateA());
            // Issue requests, which toggles state
    
            c.Request();
            c.Request();
            c.Request();
            c.Request();
        }
    }
    
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    abstract class State
    {
        public abstract void Handle(StateContext context);
    }
    
    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    class ConcreteStateA : State
    {
        public override void Handle(StateContext context)
        {
            context.State = new ConcreteStateB();
        }
    }
    
    /// <summary>
    /// A 'ConcreteState' class
    /// </summary>
    class ConcreteStateB : State
    {
        public override void Handle(StateContext context)
        {
            context.State = new ConcreteStateA();
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    class StateContext
    {
        private State _state;
        // Constructor
        public StateContext(State state)
        {
            this.State = state;
        }
        // Gets or sets the state
        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " +
                _state.GetType().Name);
            }
        }
        public void Request()
        {
            _state.Handle(this);
        }
    }
}
