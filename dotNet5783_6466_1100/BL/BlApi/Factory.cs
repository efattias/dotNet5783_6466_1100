
using BlImplementation;

namespace BlApi;
public static class Factory
{ 
    public static IBL GetBl()
    {
        IBL bL = new Bl();
        return bL;
    }
}
