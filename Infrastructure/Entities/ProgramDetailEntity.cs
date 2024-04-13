﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class ProgramDetailEntity
{
    [Key]
    public int Id { get; set; }
    public int Number { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }


}
