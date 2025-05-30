namespace server_web_lab2.Models
{
    public class Property
    {
        public string Type { get; set; } // квартира, будинок тощо
        public string District { get; set; } // район
        public double Area { get; set; } // площа, м²
        public int Rooms { get; set; } // кімнати
        public decimal Price { get; set; } // грн
        public string OperationType { get; set; } // продаж, купівля, оренда, здавання
    }
}
