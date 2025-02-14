﻿using System.ComponentModel.DataAnnotations;

namespace ASPNetServer.Data
{
    internal sealed class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }=string.Empty;
        [Required]
        [MaxLength(100000)]
        public string Content { get; set; } = string.Empty;
    }
}
