﻿using Restapi_WorkingWithFiles.Data.Converter.Contract;
using Restapi_WorkingWithFiles.Data.VO;
using Restapi_WorkingWithFiles.Model;

namespace Restapi_WorkingWithFiles.Data.Converter.Implementations
{
    public class BooksConverter : IParser<BooksVO, Books>, IParser<Books, BooksVO>
    {
        public Books Parse(BooksVO origin)
        {
            if (origin == null) return null;
            return new Books
            {
                Id = origin.Id,
                Name = origin.Name,
                Author = origin.Author,
                Publisher = origin.Publisher,
                Genre = origin.Genre
            };
        }

        public BooksVO Parse(Books origin)
        {
            if (origin == null) return null;
            return new BooksVO
            {
                Id = origin.Id,
                Name = origin.Name,
                Author = origin.Author,
                Publisher = origin.Publisher,
                Genre = origin.Genre
            };
        }

        public List<BooksVO> Parse(List<Books> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Books> Parse(List<BooksVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
