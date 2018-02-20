//window.addEventListener("load", );
var fila = 1;
var dataTable;
var tbody;
var tableHead;
var filasBorradas = 0;
var arraycosas = ["Saab", "Volvo", "BMW","alvarillolag1","123","abc","rubber pills"];

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

    td0.appendChild(document.createElement("SELECT"));
    var option = document.createElement("option");
    option.value = "";
    option.text = "Seleccione un producto";
    td0.firstChild.appendChild(option);
    for (var i = 0; i < arraycosas.length; i++)
    {
        var option = document.createElement("option");
        option.value = arraycosas[i];
        option.text = arraycosas[i];
        td0.firstChild.appendChild(option);
    }

    td0.firstChild.addEventListener("change", function ()
    {
        if (td0.firstChild.value === "") {/*a lwix le gustan los penes-- Jarana*/
            td1.innerHTML = "";
            td2.innerHTML = "";
            td3.innerHTML = "";
            td4.innerHTML = "";
        } else {
            var x = document.createElement("INPUT");
            x.setAttribute("type", "number");
            //x.setAttribute("minValue", "1");
            x.min = "1";
            x.value = "1";
            x.max = "123";
            x.onkeypress = function (evt) {
                evt.preventDefault();
            };

            td1.innerHTML = "stock" + td0.firstChild.value; //stock de la api
            td2.innerHTML = "esto es un texto de prueba largo para la descripcion del producto pa ver si va bien o que ave o no aro que si y el producto seleccionado es: " + td0.firstChild.value;//descrupcion
            if (td3.firstChild == null) {
                td3.appendChild(x); //cantidad
            }
            td4.innerHTML = "precio" + td0.firstChild.value;//precio
        }
        
    });

    
    td5.appendChild(btnDelete);

    //AÑADE A CADA BOTON ELIMINAR UN LISTENER PARA EL METODO
    btnDelete.addEventListener("click", eliminarFila, false);

    tbody.appendChild(tr);
    
    dataTable.appendChild(tbody);
    fila++;
    //}
}

function confirmarPedido() {
    //alert("pedido hacido xd")
    var pedido = "";
    //gets table
    var oTable = document.getElementById('table1');

    //gets rows of table
    var rowLength = oTable.rows.length;

    //loops through rows    
    for (i = 1; i < rowLength; i++) {

        //gets cells of current row  
        var oCells = oTable.rows.item(i).cells;

        //gets amount of cells of current row
        var cellLength = oCells.length;

        //--------------HAY QUE HACER QUE LAS QUE NO SE VEN NO SE METAN EN EN PEDIDO--------------

        //if(se ve la row)
        //loops through each cell in current row
        for (var j = 0; j < cellLength; j++) {
            if (j == 0) {
                pedido = pedido+oCells.item(j).firstChild.value+" ";
                //alert(cellVal);
            } else if (j == 3) {
                pedido = pedido+oCells.item(j).firstChild.value+" | ";
                //alert(cellVal);
            }
            // get your cell info here
            /*
            var cellVal = oCells.item(j).innerHTML;
            alert(cellVal);
            */
        }
    }
    document.getElementById("pedidoHecho").innerHTML = pedido;
    borrarTabla();
}

function eliminarFila() {
    if (document.getElementById("table1").childElementCount - 1 <= this.name) {
        document.getElementById("table1").rows.item(parseInt(this.name)).style.display = 'none';
    }

    else
    {
        document.getElementById("table1").rows.item(parseInt(this.name)).style.display = 'none';
    }
}

function borrarTabla() {

    for (var i = 1; i < document.getElementById("table1").rows.length; i++)
    {
        document.getElementById("table1").rows.item(i).style.display = 'none';
    }

}

