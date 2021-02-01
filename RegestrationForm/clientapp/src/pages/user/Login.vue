<template>
  <q-layout class="bg-blue-grey-1" view="hHh Lpr lFf">
    <q-page-container>
      <q-page padding class="row items-center justify-center">
        <div class="row full-width">
          <div class="col-md-8 offset-md-2 col-xs-12 q-pl-md q-pr-md q-pt-sm">
            <q-card flat class="bg-white text-black">
              <div class="row">
                <div class="col-md-6 col-xs-12">
                  <div class="row q-pt-md q-pb-md bg-white">
                    <div class="col-md-8 offset-2 col-xs-8">
                      <q-img
                        src="~/assets/login.png"
                        spinner-color="white"
                      ></q-img>
                    </div>
                  </div>
                </div>

                <div class="col-md-6 col-xs-12 q-pt-md">
                  <div class="q-pa-md">
                    <q-form
                      @submit="onSubmit"
                      @reset="onReset"
                      class="q-gutter-md"
                    >
                      <q-input
                        filled
                        v-model="Username"
                        label="Username *"
                        hint="Username"
                        lazy-rules
                        :rules="[
                          val =>
                            (val && val.length > 0) || 'Please Provide Your Username'
                        ]"
                      />

                      <q-input
                        filled
                        type="Password"
                        v-model="Password"
                        label="Password *"
                        lazy-rules
                        :rules="[
                          val =>
                            (val !== null && val !== '') ||
                            'Enter Valid Passowrd',
                          val =>
                            (val > 0 && val < 100) || 'Enter Valid Passowrd'
                        ]"
                      />

                      <div>
                        <q-btn label="Login" type="submit" color="primary" />
                        <q-btn
                          label="Register"
                          to="/auth/register"
                          color="primary"
                          flat
                          class="q-ml-sm"
                        />
                      </div>
                    </q-form>
                  </div>
                </div>
              </div>
            </q-card>
          </div>
        </div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script>
export default {
  name: "Login",
  data() {
    return {
      Username: null,
      Password: null,

      accept: false
    };
  },

  methods: {
    onSubmit() {
      if (this.accept !== true) {
        this.$q.notify({
          color: "red-5",
          textColor: "white",
          icon: "warning",
          message: "You need to accept the license and terms first"
        });
      } else {
        this.$q.notify({
          color: "green-4",
          textColor: "white",
          icon: "cloud_done",
          message: "Submitted"
        });
      }
    },

    onReset() {
      this.name = null;
      this.age = null;
      this.accept = false;
    }
  }
};
</script>

<style scoped></style>
