﻿using System;
using System.Collections.Generic;
using System.Text;
using UserDomain.Notificacoes;

namespace UserDomain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
