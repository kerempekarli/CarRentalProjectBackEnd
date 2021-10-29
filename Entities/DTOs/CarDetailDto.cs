using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string CalorName { get; set; }
        public int ModelYear { get; set; }

    }
}
