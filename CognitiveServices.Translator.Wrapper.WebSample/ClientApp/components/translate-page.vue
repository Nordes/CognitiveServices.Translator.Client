<template>
    <div>
        <h1>Translate API Wrapper Demo</h1>

        <p>This demonstrates how the basics of the library.</p>

        <div class="text-center">
            <p><em>Loading...</em></p>
            <h1><icon icon="spinner" pulse/></h1>            
        </div>
    </div>
</template>

<script>
export default {
//   computed: {
//     totalPages: function () {
//       return Math.ceil(this.total / this.pageSize)
//     }
//   },

  data () {
    return {
    //   forecasts: null,
    //   total: 0,
    //   pageSize: 5,
    //   currentPage: 1
    }
  },

  methods: {
    async loadPage (page) {
    //   this.currentPage = page

    //   try {
    //     var from = (page - 1) * (this.pageSize)
    //     var to = from + this.pageSize
    //     let response = await this.$http.get(`/api/translate/forecasts?from=${from}&to=${to}`)
    //     console.log(response.data.forecasts)
    //     this.forecasts = response.data.forecasts
    //     this.total = response.data.total
    //   } catch (err) {
    //     window.alert(err)
    //     console.log(err)
    //   }
    }
  },

  async created () {
    // this.loadPage(1)
  }
}
</script>

<style>
</style>
