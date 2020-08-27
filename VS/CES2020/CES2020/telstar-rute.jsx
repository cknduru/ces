'use strict';
import App from '../clientapp/src/components/App'

const e = React.createElement;

class TelstarRute extends React.Component
{
    render()
    {
        return e(
            <App />
        );
    }
}

const domContainer = document.querySelector('#telstar-rute');
ReactDOM.render(e(TelstarRute), domContainer);