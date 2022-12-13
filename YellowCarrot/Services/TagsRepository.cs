using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YellowCarrot.Data;
using YellowCarrot.Models;

namespace YellowCarrot.Services
{
    internal class TagsRepository
    {
        private readonly AppDbContext _context;

        public TagsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddTag(Tag tagToAdd)
        {
            //_context.Ingredients.Add(tagToAdd);
        }
    }
}
