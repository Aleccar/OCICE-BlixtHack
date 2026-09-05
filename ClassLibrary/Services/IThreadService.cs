namespace ClassLibrary.Services;

public interface IThreadService {
    IEnumerable<Data.Thread> GetAllThreadsByCategoryId(int id);
    IEnumerable<Data.Thread> GetRecentThreads();
}