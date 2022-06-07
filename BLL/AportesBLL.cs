using Microsoft.EntityFrameworkCore;

public class AportesBLL
{
    private Contexto _contexto;
    public AportesBLL(Contexto contexto)
    {
        _contexto = contexto;
    }
    public bool Guardar(Aportes aportes)
    {
        if (!Existe(aportes.AportesId))
            return Insertar(aportes);
        else
            return Modificar(aportes);
    }

     public bool Existe(int AportesId)
    {
        return _contexto.Aportes.Any(a => a.AportesId == AportesId);
    }
    private bool Insertar(Aportes aportes)
    {
        _contexto.Aportes.Add(aportes);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }
    private bool Modificar(Aportes aportes)
    {
        _contexto.Entry(aportes).State = EntityState.Modified;
        int cantidad = _contexto.SaveChanges();
        return ((byte)cantidad) > 0;
    }
    public Aportes Buscar(int aportesId)
    {
        var aportes = _contexto.Aportes.Find(aportesId);
        return aportes;
    }
    public bool Eliminar(int Id)
    {
        bool paso = false; try
        {
            var aportes = _contexto.Aportes.Find(Id);
            if (aportes != null)
            {
                _contexto.Aportes.Remove(aportes);
                paso = _contexto.SaveChanges() > 0;
            }
        }
        catch (System.Exception)
        { throw; }
        return paso;
    }
    public List<Aportes> GetAportes()
    {
        return _contexto.Aportes.ToList();
    }
}

