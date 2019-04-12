﻿using System;
using System.Collections.Generic;


public class IndexViewModel
{
    public IEnumerable<string> Items { get; set; }
    public Pager Pager { get; set; }
}

public class Pager
{
    public Pager(int totalItems, int? page, int pageSize = 20)
    {
        // calculate total, start and end pages
        var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
        var currentPage = page != null ? (int)page : 1;
        var startPage = currentPage - pageSize / 2;
        var endPage = currentPage + ((pageSize / 2) - 1);
        if (startPage <= 0)
        {
            endPage -= (startPage - 1);
            startPage = 1;
        }
        if (endPage > totalPages)
        {
            endPage = totalPages;
            if (endPage > 20)
            {
                startPage = endPage - (pageSize - 1);
            }
        }

        TotalItems = totalItems;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalPages = totalPages;
        StartPage = startPage;
        EndPage = endPage;
    }

    public int TotalItems { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages { get; private set; }
    public int StartPage { get; private set; }
    public int EndPage { get; private set; }
}
