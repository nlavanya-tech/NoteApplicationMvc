﻿using System;

namespace NoteApplication.Entities
{
    public class Notes
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
