using SQLite;
using NotesApp.Models;

namespace NotesApp;

public class NoteDatabase
{
    SQLiteAsyncConnection _db;

    async Task Init()
    {
        if (_db is not null) return;
        var path = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");
        _db = new SQLiteAsyncConnection(path);
        await _db.CreateTableAsync<Note>();
    }

    public async Task<List<Note>> GetAllAsync()
    {
        await Init();
        return await _db.Table<Note>()
            .OrderByDescending(n => n.Pinned)
            .ToListAsync();
    }

    public async Task<int> SaveAsync(Note note)
    {
        await Init();
        return note.Id == 0 ? await _db.InsertAsync(note) : await _db.UpdateAsync(note);
    }

    public async Task<int> DeleteAsync(Note note)
    {
        await Init();
        return await _db.DeleteAsync(note);
    }
}