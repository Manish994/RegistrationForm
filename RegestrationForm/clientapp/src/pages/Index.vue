<template>
  <div class="q-pa-md">
      <q-btn label="add" color="primary" v-on:click="openAddDialog=true"></q-btn>
    <q-markup-table>
      <thead>
        <tr>
          <th class="text-left">ID</th>
          <th class="text-left">First Name</th>
          <th class="text-left">Last Name</th>
          <th class="text-left">Branch</th>
          <th class="text-left">Email</th>
          <th class="text-left">Contact Number</th>
          <th class="text-left">Address</th>
          <th class="text-left">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in students" v-bind:key="user.id">
          <td>{{ user.id }}</td>
          <td>{{ user.firstName }}</td>
          <td>{{ user.lastName }}</td>
          <td>{{ user.branch }}</td>
          <td>{{ user.email }}</td>
          <td>{{ user.contactNumber }}</td>
          <td>{{ user.address }}</td>
          <td>
            <q-btn
              v-on:click="onupdate(user.id)"
              color="primary"
              icon-right="edit"
              no-caps
              flat
              dense
            />
          </td>
          <td>
            <q-btn
              v-on:click="onremove(user)"
              color="negative"
              icon-right="delete"
              no-caps
              flat
              dense
            />
          </td>
        </tr>
      </tbody>
    </q-markup-table>

    <q-dialog v-model="medium">
      <q-card style="width: 700px; max-width: 80vw">
        <q-card-section>
          <div class="text-h6">Edit Student</div>
          <q-icon name="close-circle-outline" />
        </q-card-section>

        <q-card-section class="q-pt-none">
          <q-input label="First Name" v-model="displayStudent.firstName"
            ><template v-slot:append> <q-icon name="person" /> </template
          ></q-input>
          <q-input label="Last Name" v-model="displayStudent.lastName"
            ><template v-slot:append> <q-icon name="person" /> </template
          ></q-input>
          <q-input label="Branch" v-model="displayStudent.branch"
            ><template v-slot:append> <q-icon name="border_color" /> </template
          ></q-input>
          <q-input label="E-Mail" v-model="displayStudent.email"
            ><template v-slot:append> <q-icon name="email" /> </template
          ></q-input>
          <q-input label="Contact Number" v-model="displayStudent.contactNumber"
            ><template v-slot:append> <q-icon name="phone" /> </template
          ></q-input>
          <q-input label="Address" v-model="displayStudent.address"
            ><template v-slot:append> <q-icon name="location_city" /> </template
          ></q-input>
        </q-card-section>

        <q-card-actions align="right" class="bg-white text-teal">
          <q-btn flat label="Update" v-on:click="saveUpdate"/>
          <q-btn flat label="Cancel" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
   
     <q-dialog v-model="openAddDialog">
      <q-card style="width: 700px; max-width: 80vw">
        <q-card-section>
          <div class="text-h6">Add Student</div>
        </q-card-section>

        <q-card-section class="q-pt-none">
          <q-input label="First Name" v-model="displayStudentnew.firstName"
            ><template v-slot:append> <q-icon name="person" /> </template
          ></q-input>
          <q-input label="Last Name" v-model="displayStudentnew.lastName"
            ><template v-slot:append> <q-icon name="person" /> </template
          ></q-input>
          <q-input label="Branch" v-model="displayStudentnew.branch"
            ><template v-slot:append> <q-icon name="border_color" /> </template
          ></q-input>
          <q-input label="E-Mail" v-model="displayStudentnew.email"
            ><template v-slot:append> <q-icon name="email" /> </template
          ></q-input>
          <q-input label="Contact Number" v-model="displayStudentnew.contactNumber"
            ><template v-slot:append> <q-icon name="phone" /> </template
          ></q-input>
          <q-input label="Address" v-model="displayStudentnew.address"
            ><template v-slot:append> <q-icon name="location_city" /> </template
          ></q-input>
        </q-card-section>

        <q-card-actions align="right" class="bg-white text-teal">
          <q-btn flat label="SAVE" v-on:click="saveAddDialog" />
          <q-btn flat label="CANCEL" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

    
  </div>
</template>

<script>
export default {
  data() {
    return {
      students: [],
      medium: false,
      displayStudent: {
        id: "",
        firstName: "",
        lastName: "",
        branch: "",
        email: "",
        contactNumber: "",
        address: "",
      },
       displayStudentnew: {
        firstName: "",
        lastName: "",
        branch: "",
        email: "",
        contactNumber: "",
        address: "",
      },
      openAddDialog: false,
    };
  },
  methods: {
    getStudents: async function () {
      let vm = this;
      const response = await vm.$axios.get("students");
      vm.students = response.data;
    },

    onupdate: async function (id) {
      let vm = this;
      let response = await vm.$axios.get(`student/` + id);
      this.medium = true;
      vm.displayStudent = response.data;
    },

    saveUpdate: async function () {
      let vm = this;
      let response = await vm.$axios.post(
        "saveUpdate-studentDetails",
        vm.displayStudent
      );
      vm.$q.notify({
        message: response.data,
        color: "green",
      });
      this.displayStudent = "";
      this.getStudents();
    },

    saveAddDialog:async function(){
        let vm=this;
        let response =  await vm.$axios.post('create-studentDetails', vm.displayStudentnew);
        console.log(vm.displayStudentnew);
        vm.$q.notify({
               message: response.data,
               color: 'green'
           });
           this.getStudents();
           this.displayStudentnew="";
    },

    onremove: async function (item) {
      let vm = this;
      vm.$q
        .dialog({
          title: "Confim",
          message: "Would you like to delete?",
          cancel: true,
          persistent: true,
        })
        .onOk(async () => {
          let response = await vm.$axios.post("del-student", item);
          await vm.getStudents();
          vm.$q.notify({
            message: response.data,
            color: "red",
          });
        });
    },

    saveStudent: async function () {
      this.medium = true;
      let vm = this;
    },

    // saveStudent:async function(){
    //     let vm=this
    //     let response =  await vm.$axios.post('create-studentDetails', vm.displayStudent)
    //     this.detail=''
    // }
  },
  async mounted() {
    let vm = this;
    vm.$q.loading.show();
    await vm.getStudents();
    vm.$q.loading.hide();
  },
};
</script>