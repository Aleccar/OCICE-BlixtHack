using ClassLibrary.Data;
using Thread = ClassLibrary.Data.Thread;

namespace ClassLibrary.Services;

public class ThreadService(BlixtHackDbContext context) : IThreadService {
    private readonly BlixtHackDbContext _context = context;

    public IEnumerable<Thread> GetAllThreadsByCategoryId(int id) {
        var threads = _context.Threads.Where(t => t.ThreadCategory.Id == id);
        return threads;
    }

    public IEnumerable<Thread> GetRecentThreads() {
        throw new NotImplementedException();
    }
}