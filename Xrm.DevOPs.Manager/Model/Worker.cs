using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.Manager.Model
{
    public class Worker
    {
        private BackgroundWorker _worker;

        public void WorkAsync(WorkAsyncInfo info)
        {
            _worker = new BackgroundWorker
            {
                WorkerReportsProgress = info.ProgressChanged != null,
                WorkerSupportsCancellation = info.IsCancelable
            };
            _worker.DoWork += info.PerformWork;


            if (_worker.WorkerReportsProgress && info.ProgressChanged != null)
            {
                _worker.ProgressChanged += info.PerformProgressChange;
            }

            _worker.RunWorkerCompleted += (s, e) =>
            {
                if (info.PostWorkCallBack != null)
                {
                    info.PostWorkCallBack(e);
                }
            };

            _worker.RunWorkerAsync(info.AsyncArgument);
        }
    }
}
