using Automatonymous;
using System;
using Contracts;

namespace TestSubscriber
{
    public class OrderSaga : MassTransitStateMachine<SagaInstance>
    { 
        public Event<IOrder> Create { get; set; }
        public Event<IOrderApproved> Approved { get; set; }
        public Event<IOrderRejected> Rejected { get; set; }
        public Event<IPicked> Picked { get; set; }
        public State Approve { get; set; }
        public State Pick { get; set; }
        public State Completed { get; set; }
       
        public Guid CorrelationId => throw new NotImplementedException();

        public OrderSaga()
        {
            InstanceState(x => x.CurrentState);

            Initially(
                When(Create)
                .Then(context => Console.WriteLine($"{context.Data.What}: Order created, sending approval request"))
                .Publish(context => new ApproveOrder
                {
                    CorrelationId = context.Instance.CorrelationId,
                    Text = context.Data.What
                })
                .TransitionTo(Approve));

            During(Approve,
                When(Approved)
                .Then(context => Console.WriteLine($"{context.Data.Text}: Approval received, sending pick request"))
                .Publish(context => new OrderPick { What = context.Data.Text, CorrelationId = context.Instance.CorrelationId })
                .TransitionTo(Pick),
                When(Rejected)
                .Then(context => Console.WriteLine($"State {context.Data.Text} is getting rejected"))
                .Finalize());

            During(Pick,
                When(Picked)
                .Then(context => Console.WriteLine($"{context.Data.Text}: Picking complete, workflow ends"))
                .Finalize());

            SetCompletedWhenFinalized();
        }
    }

    public class SagaInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        public string CurrentState { get; set; }

        public SagaInstance(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
    }
}