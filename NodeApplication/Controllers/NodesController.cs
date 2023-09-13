using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NodeApplication.Data;
using NodeApplication.Models;

namespace NodeApplication.Controllers
{
    public class NodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult IsActive()
        {
            var activeNodes = _context.nodes
                .Where(node => node.IsActive)
                .ToList();

            return View(activeNodes);
        }

        
        // GET: Nodes
        public async Task<IActionResult> Index()
        {
              return _context.nodes != null ? 
                          View(await _context.nodes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.nodes'  is null.");
        }

       



        // GET: Nodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.nodes == null)
            {
                return NotFound();
            }

            var node = await _context.nodes
                .FirstOrDefaultAsync(m => m.NodeId == id);
            if (node == null)
            {
                return NotFound();
            }

            return View(node);
        }

        // GET: Nodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nodes/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NodeId,NodeName,ParentNodeId,IsActive,StartDate")] Node node)
        {
            if (ModelState.IsValid)
            {
                _context.Add(node);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(node);
        }

        // GET: Nodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.nodes == null)
            {
                return NotFound();
            }

            var node = await _context.nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }
            return View(node);
        }

        // POST: Nodes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NodeId,NodeName,ParentNodeId,IsActive,StartDate")] Node node)
        {
            if (id != node.NodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(node);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NodeExists(node.NodeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(node);
        }

        // GET: Nodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.nodes == null)
            {
                return NotFound();
            }

            var node = await _context.nodes
                .FirstOrDefaultAsync(m => m.NodeId == id);
            if (node == null)
            {
                return NotFound();
            }

            return View(node);
        }

        // POST: Nodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.nodes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.nodes'  is null.");
            }
            var node = await _context.nodes.FindAsync(id);
            if (node != null)
            {
                _context.nodes.Remove(node);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NodeExists(int id)
        {
          return (_context.nodes?.Any(e => e.NodeId == id)).GetValueOrDefault();
        }
    }
}
