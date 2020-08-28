using System;

namespace CES2020.Integrations.dtos
{
    public class ForsendelseDto
    {
            public string[] GoodsTypeIds { get; set; }

            public int Weight { get; set; }

            public int Length { get; set; }

            public int Width { get; set; }

            public int Height { get; set; }

            public DateTime DeliveryDate { get; set; }
    }
}