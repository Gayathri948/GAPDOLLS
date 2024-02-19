﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GAPDOLLS.Models;

public class DollSkinToneViewModel
{
    public List<Dolls>? Dolls { get; set; }
    public SelectList? SkinTone { get; set; }
    public string? DollSkinTone { get; set; }
    public string? SearchString { get; set; }
}