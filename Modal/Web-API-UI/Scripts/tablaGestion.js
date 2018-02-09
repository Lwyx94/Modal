//window.addEventListener("load", );
var fila = 1;
var dataTable;
var tbody;
var tableHead;
var filasBorradas = 0;

function displayResult() {
    //document.getElementById("table1").insertRow(-1).innerHTML = '<td>Producto</td><td>Stock</td><td>Descripción</td><td>Cantidad</td><td>Precio Total</td>';
    dataTable = document.getElementById('table1');
    tableHead = document.getElementById('table-head');
    tbody = document.createElement('tbody');
    

    /*while (dataTable.firstChild) {
        dataTable.removeChild(dataTable.firstChild);
    }*/

    dataTable.appendChild(tableHead);
    var tr = document.createElement('tr'),
        td0 = document.createElement('td'),
        td1 = document.createElement('td'),
        td2 = document.createElement('td'),
        td3 = document.createElement('td'),
        td4 = document.createElement('td'),
        td5 = document.createElement('td'),
        btnDelete = document.createElement('input');

    btnDelete.setAttribute('type', 'button');
    btnDelete.setAttribute('class', 'btnDelete');
    btnDelete.setAttribute('id', fila);
    btnDelete.setAttribute('value', "Eliminar");
    btnDelete.setAttribute('name', fila);

    tr.appendChild(td0);
    tr.appendChild(td1);
    tr.appendChild(td2);
    tr.appendChild(td3);
    tr.appendChild(td4);
    tr.appendChild(td5);

    //td0.innerHTML = i + 1;
    td0.innerHTML = "asdasda"+fila;//meter el select de productos
    td1.innerHTML = "asdasda" + fila; //stock
    td2.innerHTML = "asdasda" + fila;//descrupcion
    td3.innerHTML = "asdasda" + fila; //cantidad
    td4.innerHTML = "asdasda" + fila;//precio
    td5.appendChild(btnDelete);

    //AÑADE A CADA BOTON ELIMINAR UN LISTENER PARA EL METODO
    btnDelete.addEventListener("click", eliminarFila, false);

    tbody.appendChild(tr);
    
    dataTable.appendChild(tbody);
    fila++;
    //}
}

function eliminarFila() {
    if (document.getElementById("table1").childElementCount - 1 <= this.name) {
        document.getElementById("table1").deleteRow(parseInt(this.name) - filasBorradas);
    }

    else
    {
        document.getElementById("table1").deleteRow(this.name);
    }
    filasBorradas++;
    fila--;
}

function borrarTabla() {

    while (dataTable.firstChild) {
        
        dataTable.removeChild(dataTable.firstChild);
    }
    fila = 1;
}

