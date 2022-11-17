using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface ICrud<T>
{
    public int add(ICrud<T> item);
    public void delete(int id);
    public void update(T? item);
    public ICrud<T> getByID(int id);
    public IEnumerable<T> getAll();


}
