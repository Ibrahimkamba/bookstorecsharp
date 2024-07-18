using System;
using System.Collections.Generic;

namespace BookStoreApp.Data
{
    public class Book
    {
        public int B_ID { get; set; }
        public string B_TITLE { get; set; }
        public int B_A_ID { get; set; }
        public string B_PUBLISHER { get; set; }
        public DateTime B_PUB_DATE { get; set; }
        public string B_SUBJECT { get; set; }
        public decimal B_UNIT_PRIZE { get; set; }
        public int B_STOCK { get; set; }

        public Author Author { get; set; }
    }

    public class Author
    {
        public int A_ID { get; set; }
        public string A_FNAME { get; set; }
        public string A_LNAME { get; set; }

        public ICollection<Book> Books { get; set; }
    }

    public class Customer
    {
        public int C_ID { get; set; }
        public string C_NAME { get; set; }
        public string C_ADD { get; set; }
    }

    public class Reservation
    {
        public int R_ID { get; set; }
        public int R_C_ID { get; set; }
        public string R_C_NAME { get; set; }
        public int R_B_ID { get; set; }
        public string R_B_TITLE { get; set; }
        public int R_B_QUANTITY { get; set; }

        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
}
