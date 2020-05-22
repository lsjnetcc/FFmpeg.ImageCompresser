using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg.ImageCompresser
{
	public sealed class UIHelper
	{
		public static void RenderOnUIThread(Control frmOrControl, Action execAction)
		{
			if (frmOrControl.InvokeRequired)
			{
				frmOrControl.Invoke(execAction);
			}
			else
			{
				execAction();
			}
		}
		public static void RenderOnUIThread<TInput>(Control frmOrControl, Action<TInput> execAction, TInput args)
		{
			if (frmOrControl.InvokeRequired)
			{
				frmOrControl.Invoke(execAction, new object[] { args });
			}
			else
			{
				execAction(args);
			}
		}
	}
}
