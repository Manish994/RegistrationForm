<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
  <q-page padding class="items-center-justify-center bg-grey-3">
    <q-card flat class="bg-white q-pa-md">
      <span class="text-h5 text-weight-light q-pa-md">
        <span class="text-blue-grey-14">Add New Student</span>
      </span>
      <div class="q-pa-md">
        <q-form class="q-gutter-md">
          <q-input
            label="First Name"
            lazy-rules
            color="teal"
            v-model="detail.firstName"
            :rules="[
              (val) =>
                (val !== null && val !== '') || 'Please Provide First Name',
            ]"
          >
            <template v-slot:append>
              <q-icon name="person" />
            </template>
          </q-input>

          <q-input
            label="Last Name"
            lazy-rules
            color="teal"
            v-model="detail.lastName"
            :rules="[
              (val) =>
                (val !== null && val !== '') || 'Please Provide Last Name',
            ]"
          >
            <template v-slot:append>
              <q-icon name="person" />
            </template>
          </q-input>

          <q-input
            label="Branch"
            lazy-rules
            color="teal"
            v-model="detail.branch"
            :rules="[
              (val) => (val !== null && val !== '') || 'Please Provide Branch',
            ]"
          >
            <template v-slot:append>
              <q-icon name="border_color" />
            </template>
          </q-input>

          <q-input
            label="E-Mail"
            lazy-rules
            color="teal"
            v-model="detail.email"
            :rules="[
              (val) =>
                (val !== null && val !== '') || 'Please Provide Valid E-Mail',
            ]"
          >
            <template v-slot:append>
              <q-icon name="email" />
            </template>
          </q-input>

          <q-input
            label="Contact Number"
            lazy-rules
            color="teal"
            v-model="detail.contactNumber"
            :rules="[
              (val) =>
                (val !== null && val !== '') || 'Please Provide Contact Number',
            ]"
          >
            <template v-slot:append>
              <q-icon name="phone" />
            </template>
          </q-input>

          <q-input
            label="Address"
            lazy-rules
            color="teal"
            v-model="detail.address"
            :rules="[
              (val) => (val !== null && val !== '') || 'Please Provide Address',
            ]"
          >
            <template v-slot:append>
              <q-icon name="location_city" />
            </template>
          </q-input>

          <div>
            <q-btn
              unelevated
              icon="add"
              label="Create new student"
              style="height: 50px"
              color="teal-6"
              v-on:click="onSubmit"
            />
          </div>
        </q-form>
      </div>
    </q-card>
  </q-page>
</template>
 
<script>
  export default {
    data() {
      return {
        detail: {
          firstName: '',
          lastName: '',
          branch: '',
          email: '',
          contactNumber: '',
          address: '',
        },
      };
    },

    methods:{
        onSubmit: async function(){
           let vm=this
           let response =  await vm.$axios.post('create-studentDetails', vm.detail)
           vm.$router.push("list");
           vm.$q.notify({
               message: response.data,
               color: 'green'
           })
        },
    },
   
  };
</script>
 
<style scoped>
</style>