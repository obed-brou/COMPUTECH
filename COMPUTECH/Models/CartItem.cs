﻿namespace COMPUTECH.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
    }

}
