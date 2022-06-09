using Microsoft.EntityFrameworkCore;

public class AporteBLL
{
    private Contexto _contexto;
    public AporteBLL(Contexto contexto)
    {
        _contexto = contexto;
    }
    public bool Guardar(Aporte aporte)
    {
        if (!Existe(aporte.AporteId))
            return Insertar(aporte);
        else
            return Modificar(aporte);
    }
    public bool Existe(int aporteId)
    {
        return _contexto.Aporte.Any(a => a.AporteId == aporteId);
    }
    private bool Insertar(Aporte aporte)
    {
        _contexto.Aporte.Add(aporte);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }
    private bool Modificar(Aporte aporte)
    {
        _contexto.Entry(aporte).State = EntityState.Modified;
        int cantidad = _contexto.SaveChanges();
        return ((byte)cantidad) > 0;
    }
    public Aporte Buscar(int aporteId)
    {
        var aportes = _contexto.Aporte.Find(aporteId);
        return aportes;
    }
    public bool Eliminar(int Id)
    {
        bool paso = false; try
        {
            var aporte = _contexto.Aporte.Find(Id);
            if (aporte != null)
            {
                _contexto.Aporte.Remove(aporte);
                paso = _contexto.SaveChanges() > 0;
            }
        }
        catch (System.Exception)
        { throw; }
        return paso;
    }
    public List<Aporte> GetAportes()
    {
        return _contexto.Aporte.ToList();
    }
}