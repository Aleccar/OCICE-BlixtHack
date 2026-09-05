using Thread = ClassLibrary.Data.Thread;

namespace OCICE_BlixtHack.Models;

public class ThreadsVM {
    public IEnumerable<Thread> Threads { get; set; }
    public string CategoryName { get; set; }
}