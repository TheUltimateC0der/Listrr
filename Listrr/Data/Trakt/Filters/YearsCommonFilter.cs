﻿using System.ComponentModel.DataAnnotations;

namespace Listrr.Data.Trakt.Filters
{
    public class YearsCommonFilter
    {

        [Display(Name = "Min year", Prompt = "1990")]
        public int? From { get; set; }

        [Display(Name = "Max year", Prompt = "2018")]
        public int? To { get; set; }

    }
}