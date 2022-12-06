using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;
/// <summary>
/// interface for implement CRUD functions
/// </summary>
public interface ICrud<T> where T : struct
{
    /// <summary>
    /// function- add item to list. returns int
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
     int Add(T? item);
    
    /// <summary>
    /// /// function- delete item from list
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
    
    /// <summary>
    /// funcion - update item in list(by delete and add)
    /// </summary>
    /// <param name="item"></param>
     void Update(T? item);
    
    /// <summary>
    /// function- returns item by sending given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
     T GetByID(int id);
    
    /// <summary>
    /// funcion- returns item list
    /// </summary>
    /// <returns></returns>
     IEnumerable<T?> getAll(Func<T?,bool>? filter = null);
    //אם מוסיפים שדה נמחק להוסיף פונקציה שמחזיקה עם הנמחקים
}
