<template>
    
</template>

<script>
    import userVault from '@/components/userVault.vue'
export default {
    name: 'Vaults', 
    mounted() {
        this.$store.dispatch("getVaults")
        //get all vaults
    },
    data(){
        return {

        }
    }, 
    computed: {
        user() {
            return this.$store
        }
    }, 
    components: {
        userVault //called?
    }, 
    methods: {
        createVault() {
            this.$store.dispatch("createVault")
        }
    }

}
</script>

<style>

</style>
