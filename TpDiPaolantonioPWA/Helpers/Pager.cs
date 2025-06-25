

namespace TpDiPaolantonioPWA.Helpers
{
    public class Pager
    {
        public int ItemsTotales { get; set; }
        public int PaginaActual { get; set; }
        public int PaginaTamanio { get; set; }
        public int TotalPaginas { get; set; }
        public int ComienzoPagina {  get; set; }
        public int FinPagina {  get; set; }


        public Pager() { }
        public Pager(int itemsTotales, int paginaActual, int paginaTamanio = 10) 
        {
            ItemsTotales = itemsTotales;
            PaginaActual = paginaActual;
            PaginaTamanio= paginaTamanio;

            TotalPaginas = (int)Math.Ceiling((decimal)ItemsTotales / (decimal)PaginaTamanio);

            ComienzoPagina = PaginaActual - 5;
            FinPagina = PaginaActual +4;

            if (ComienzoPagina <= 0)
            {
                FinPagina -= (ComienzoPagina - 1);
                ComienzoPagina = 1;
            }

            if (FinPagina > TotalPaginas)
            {
                FinPagina = TotalPaginas;

                if(FinPagina > 10) 
                {
                    ComienzoPagina = FinPagina - 9;
                }
            }

        }
    }
}
