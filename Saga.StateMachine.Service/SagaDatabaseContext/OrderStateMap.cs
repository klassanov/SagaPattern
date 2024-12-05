using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Saga.StateMachine.Service.SagaStateMachine;

namespace Saga.StateMachine.Service.SagaDatabaseContext
{
    public class OrderStateMap : SagaClassMap<OrderState>
    {
        //public override void Configure(ModelBuilder model)
        //{
        //    base.Configure(model);
        //}
    }
}
