import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import listPlugin from '@fullcalendar/list';
import { BackendService } from 'src/app/backend.service';
import { StorageService } from 'src/app/storage.service';
import { InvoiceService } from 'src/app/invoice.service';
import pdfMake from "pdfmake/build/pdfmake";
import pdfFonts from "pdfmake/build/vfs_fonts";
pdfMake.vfs = pdfFonts.pdfMake.vfs;

declare let $: any;

function padTo2Digits(num) {
  return num.toString().padStart(2, '0');
}

function formatDate(date) {
  return (
    [
      date.getFullYear(),
      padTo2Digits(date.getMonth() + 1),
      padTo2Digits(date.getDate()),
    ].join('-') +
    'T' +
    [
      padTo2Digits(date.getHours()),
      padTo2Digits(date.getMinutes()),
      padTo2Digits(date.getSeconds()),
    ].join(':')
  );
}

@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements OnInit {
  // Variables necesarias
  services_lavacar: []
  sucursales: []
  appoinments: []
  snacks = ''

  identificationClient = ''

  selectedStore: String;
  selectedService: String;

  Events = [];

  tempEvent: any;

  calendarOptions!: CalendarOptions;

  user: any;

  // Constructor de la clase
  constructor(private invoice: InvoiceService, private localSotage: StorageService, private backend: BackendService) {

    this.user = JSON.parse(this.localSotage.getData('user'));

    //Asignar variable local Servicios lavado
    this.backend.getServices().subscribe(
      response => {
        this.localSotage.saveData('lavados', JSON.stringify(response))
      }
    )
    this.services_lavacar = JSON.parse(this.localSotage.getData('lavados'))

    //Asignar variable local Sucursales
    this.backend.getStores().subscribe(
      response => {
        this.localSotage.saveData('stores', JSON.stringify(response))
      }
    )
    this.sucursales = JSON.parse(this.localSotage.getData('stores'))

    //Asignar variable local citas
    this.backend.getAppointments().subscribe(
      response => {
        this.localSotage.saveData('appoinments', JSON.stringify(response))
      }
    )
    this.appoinments = JSON.parse(this.localSotage.getData('appoinments'))

    this.appoinments.map(a=>{
      let temp = {
        id: a['cita_id'],
        start: a['date'],
        title: a['cedula'],
        suc_id: a['suc_id'],
        cedula: a['cedula'],
        lavado_id: a['lavado_id'],
        trabajador_id: a['trabajador_id']
      }

      this.Events.push(temp);

    })

  }

  //Funcion para guardar las citas en el calendario y la base de datos
  handleSave() {
    if (this.selectedService) {
      this.tempEvent['id'] = this.identificationClient,
        this.tempEvent['title'] = this.identificationClient,
        this.tempEvent['trabajador_id'] = 1,
        this.tempEvent['suc_id'] = this.selectedStore,
        this.tempEvent['cedula'] = this.identificationClient,
        this.tempEvent['lavado_id'] = this.selectedService
      this.Events.push(this.tempEvent);

      this.backend.postAppoiment(this.tempEvent).subscribe(res=>console.log('Agragado correctamente'))

      $("#myModal").modal("hide");
    } else {
      alert('Debe seleccionar un servicio')
    }
  }
  //Funcion para crear facturas
  handleFacturation() {
    this.user = JSON.parse(this.localSotage.getData('user'));

    let store = this.sucursales.find(e => Number(e['suc_id']) === Number(this.tempEvent['suc_id']))
    let wash = this.services_lavacar.find(e => Number(e['lavado_id']) === Number(this.tempEvent['lavado_id']))

    this.invoice.invoice.products = 
    [
      { name: wash['lavado_nombre'], price: Number(wash['precio']), qty: 1 }, 
      { name: 'Free Snacks', price: 0, qty: 5 },
      { name: 'Snacks', price : 500, qty: Number(this.snacks)}
    ]
    this.invoice.invoice.customerName = this.user.cliente_nombre
    this.invoice.invoice.contactNo = this.user.cedula
    this.invoice.invoice.email = this.user.email
    this.invoice.invoice.address = store['provincia']
    
    this.invoice.generatePDF()
  }

  //Funcion para a gregar citas
  eventClick(res: any) {
    this.tempEvent = this.Events.find(e => Number(e.id) === Number(res.event.id))
    $("#myModal2").modal("show");
    $(".modal-title").text("Facturation");
  }
//Funcion para a agregar citas
  onDateClick(res: any) {
    if (!res.allDay) {

      let date = formatDate(res.date)

      $("#myModal").modal("show");
      $(".modal-title").text("Choose Service");
      $(".modal-title").text("Add Event at : " + date);

      this.tempEvent = {
        start: date,
        date: date
      }

    }

  }

  ngOnInit() {

    setTimeout(() => {
      this.calendarOptions = {
        plugins: [dayGridPlugin, timeGridPlugin, listPlugin],
        selectable: true,
        eventClick: this.eventClick.bind(this),
        dateClick: this.onDateClick.bind(this),
        eventChange: () => { console.log(this.Events) },
        events: this.Events,
        editable: true,
        headerToolbar: {
          left: 'prev,next today',
          center: 'title',
          right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
      };
    }, 3500);

  }

}