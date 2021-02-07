using System;

namespace LibraryDesafioAPI.Classes
{
    public partial class Devedor : IDisposable
    {
        public Devedor()
        {
            this._CodigoDevedor = Convert.ToInt32(Next());
            this._isNew = true;
            this._isModified = false;
        }

        public Devedor(int codigo)
        {
            SetSelf(GetByPrimaryKey(codigo));
            this._isNew = false;
            this._isModified = false;
        }

        public void Dispose()
        {
            this.Gravar();
        }
    }
}
