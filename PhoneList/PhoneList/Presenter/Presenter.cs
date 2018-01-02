﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneList
{
    public class Presenter: IPresenter
    {
        IView _view;
        IInteractor _interactor;

        public Presenter(IView view, IInteractor interactor)
        {
            _view = view ?? throw new ArgumentNullException();
            _interactor = interactor ?? throw new ArgumentNullException();
        }

        public List<int> GetAllIdList()
        {
            var idList = _interactor.GetAllIdList();
            return idList;
        }

        public async Task GetNextUser()
        {
            //CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            //CancellationToken token = cancelTokenSource.Token;

            await Task.Run(async () =>
            {
                ViewModel model = await _interactor.GetNextUser();
                
                if (model == null)
                {
                    _view.SetFName("");
                    _view.SetLName("");
                }
                else
                {
                    _view.SetFName(model.fname);
                    _view.SetLName(model.lname);
                }
                //await Task.Delay(2000);
            }
            );
        }

        public async Task Init(int id)
        {
            ViewModel model = await _interactor.Get(id);

            if (model == null)
            {
                _view.SetFName("");
                _view.SetLName("");
            }
            else
            {
                _view.SetFName(model.fname);
                _view.SetLName(model.lname);
            }
        }


    }
}