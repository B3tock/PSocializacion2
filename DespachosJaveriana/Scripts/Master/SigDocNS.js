	var SigDoc = (function() {
		'use strict';

		var CtrlSimpleDialog;
		var CtrlSimpleDialogContent;
		var CtrlSimpleDialogTitle;


		function CallPopUpWindowWithAccepAction(title, content, url) {



			AssigModalContent(title, content);

			CtrlSimpleDialog.dialog({
				modal: true,
				buttons: {
					Aceptar: function() {
						$(this).dialog("close");
							//location.href=url;
					}
				}
			})
		}

		function CallPopUpWindowOnlyWithOkButton(title, content) {


			AssigModalContent(title, content);

			CtrlSimpleDialog.dialog({
				modal: true,
				buttons: {
					Ok: function() {
					    $(this).dialog("close");
					}
				}
			});

			CtrlSimpleDialog.dialog("open");
		}

		/**
		 * @title {string} New Modal Tittle 
		 * @content {string} New Modal Content
		 */
		function AssigModalContent(title, content) {
			
			CtrlSimpleDialog = $("#dialog-message");
			CtrlSimpleDialogContent = $("#msjContent");
			CtrlSimpleDialogTitle = $("#msjTitle");

			CtrlSimpleDialogContent.text(content);
			CtrlSimpleDialogTitle.text(title);
		}

		var SigDoc = {
			PopUpWithAcion: CallPopUpWindowWithAccepAction,
			AlertMsj: CallPopUpWindowOnlyWithOkButton
		};

		return SigDoc;
	}());

