using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Staff
    {
        public int ID { set; get; }
        public string S_ID { set; get; }
        public string S_Name { set; get; }
        public string S_Birth { set; get; }
        public int S_Gender { set; get; }
        public string S_Phone { set; get; }
        public string S_Email { set; get; }
        public string S_Pass { set; get; }
        public int D_ID { set; get; }
        /*
         *  @S_ID nvarchar(20),         
        @S_Name nvarchar(30),        
        @S_Birth nvarchar(20),        
        @S_Gender int,
	    @S_Phone nvarchar(20),
	    @S_Email nvarchar(20),
	    @S_Pass nvarchar(50),
	    @D_ID int    
         */
    }
}
