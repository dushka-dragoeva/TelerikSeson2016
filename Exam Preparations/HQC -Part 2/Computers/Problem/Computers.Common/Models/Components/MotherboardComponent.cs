using System;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Components
{
   public abstract class MotherboardComponent : IMotherboardComponent
    {
        public IMotherboard Motherboard { get; set; }
    }
}