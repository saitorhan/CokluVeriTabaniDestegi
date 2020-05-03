using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CokluDbDestegi
{
    interface IKisi
    {
        int KisiEkle(Kisi yeniKisi);
        List<Kisi> KisileriGetir();
    }
}
